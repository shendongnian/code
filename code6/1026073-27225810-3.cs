    	public class AdvancedMetaModel : MetaModel
	{
		/// <summary>
		/// Creates the table.
		/// </summary>
		/// <param name="provider">The provider.</param>
		/// <returns></returns>
		protected override MetaTable CreateTable(TableProvider provider)
		{
			return new AdvancedMetaTable(this, provider);
		}
	}
	public class AdvancedMetaTable : MetaTable
	{
		private SecureMetaModel SecureModel { get { return (SecureMetaModel)this.Model; } }
		public String GetMethodName { get; set; }
		private MethodInfo CreateQueryMethod { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="AdvancedMetaTable"/> class.
		/// </summary>
		/// <param name="metaModel">The meta model.</param>
		/// <param name="tableProvider">The table provider.</param>
		public AdvancedMetaTable(MetaModel metaModel, TableProvider tableProvider) :
			base(metaModel, tableProvider)
		{
			// set the Get Method Name
			var context = base.CreateContext();
			var getMethodName = DefaultGetMethodName;
			if (context != null && context.HasMethod(DefaultGetMethodName))
			{
				GetMethodName = getMethodName;
				this.CreateQueryMethod = this.DataContextType.GetMethod(GetMethodName);
			}
			else
				GetMethodName = String.Empty;
		}
		internal String DefaultGetMethodName
		{
			get { return String.Format("Get{0}", DataContextPropertyName); }
		}
		public override IQueryable GetQuery(object context)
		{
			var filterByAttribute = this.GetAttribute<FilterByAttribute>();
			if (this.CreateQueryMethod != null)
			{
				if (context == null)
					context = this.CreateContext();
				//this.Provider.GetQuery(context);
				var query = (IQueryable)this.CreateQueryMethod.Invoke(context, null);
				if (this.SortColumn != null)
					return query.GetQueryOrdered((MetaTable)this);
				else
					return query;
			}
			else if (filterByAttribute != null)
			{
				MetaColumn filterByColumn = this.GetColumn(filterByAttribute.ColumnName);
				var query = base.GetQuery(context).GetQueryFilteredByColumn(filterByColumn, filterByAttribute.ValueWhenTrue);
				return query;
			}
			else
			{
				var query = base.GetQuery(context);
				return query;
			}
		}
	}
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
