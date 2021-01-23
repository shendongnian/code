     [HttpGet]
        public ApiQueryResult<CustomersView> CustomersViewsRow(int id)
        {
            var ret = new ApiQueryResult<CustomersView>(this.Request);
            ret.Content = this.BLL.GetOneCustomer(id);
            ret.AddHeaders("myCustomHkey","myCustomValue");
            return ret;
        }
