    CreatedNegotiatedContentResult<T> Created<T>(T content)
        {
            var props =typeof(T).GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(UniqueIdAttribute)));
            if (props.Count() == 0)
            {
                //log this, the UniqueId attribute is not defined for this model
                return base.Created(Request.RequestUri.ToString(), content);
            }
            var id = props.FirstOrDefault().GetValue(content).ToString();
            return base.Created(new Uri(Request.RequestUri + id), content);
         }
