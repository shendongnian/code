    protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list =  this.FetchBindableList();
            this.DropDownList1.DataSource =  list;
            this.DropDownList1.DataBind();
        }
        private List<string> FetchBindableList()
        {
            List<string> list = new List<string>();
            FieldInfo[] fieldInfos = typeof(ListEnum).GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                Attribute attribute = fieldInfo.GetCustomAttribute(typeof(EnumBindableAttribute));
                if (attribute != null)
                {
                    list.Add(fieldInfo.Name);
                }
            }
            return list;
        }
