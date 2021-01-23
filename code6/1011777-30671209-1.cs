    public class ControllerModelBinder<T> : DefaultModelBinder
      where T : BaseModel
    {
      public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
        if (bindingContext.ModelType == typeof(T))
        {
          string hash = bindingContext.ValueProvider.GetValue("id").RawValue.ToString();
          if (!string.IsNullOrWhiteSpace(hash))
          {
            int id = HashIdHelper.ToInt(hash);
            if (id > 0)
            {
              using (ApplicationContext context = new ApplicationContext())
              {
                DbRawSqlQuery<T> query = context.Database.SqlQuery<T>(string.Format("SELECT * FROM {0} WHERE id = @Id LIMIT 1", EntityHelper.GetTableName<T>(context)), new MySqlParameter("@Id", id));
                try
                {
                  T model = query.Cast<T>().FirstOrDefault();
                  if (model != null)
                  {
                    return model;
                  }
                }
                catch (Exception ex)
                {
                  if (ex is ArgumentNullException || ex is InvalidCastException)
                  {
                    return base.BindModel(controllerContext, bindingContext);
                  }
                  throw;
                }
              }
            }
          }
        }
        return base.BindModel(controllerContext, bindingContext);
      }
    }
