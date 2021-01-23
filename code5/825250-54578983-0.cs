        [HttpGet]
        public object Get(int id)
        {
            object result = "";
            var db = new dbEntities();
            var EO = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>; //needed to return proper JSON without escape slashes
            try
            {
                
                IEnumerable<usp_GetComplaint_Result> aRow =  db.usp_GetComplaint(id);
                string DBL_QUOTE = new string(new char[] { '"' });
                result = "{";
                foreach (usp_GetComplaint_Result oneRow in aRow)
                {
                    System.Reflection.PropertyInfo[] properties = typeof(usp_GetComplaint_Result).GetProperties();
                    foreach(System.Reflection.PropertyInfo property in properties)
                    {
                        var vValue = property.GetValue(oneRow) == null ? "null" : property.GetValue(oneRow);
                        EO.Add(property.Name,vValue);
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                EO.Add("Error", result);
            }
            finally
            {
                db.Dispose();
            }
            return Ok(EO);
            
        }
