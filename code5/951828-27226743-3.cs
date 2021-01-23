            /// <summary>
        /// Creates or Updates a single bean, for update ensure that the name_value_list contains the ID of the record
        /// name_value_lists - Dictionary where the keys of the are the SugarBean attributes (columns), the values of the array are the values the attributes should have.
        /// </summary>
        /// <param name="module">Module to update i.e Account</param>
        /// <param name="record">key value pair object of record, include ID for update</param>
        /// <returns>Returns the updated or created Bean ID</returns>
        public string CreateUpdateBean(string module, object record)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("session", SessionID);
            parameters.Add("module_name", module);
            parameters.Add("name_value_list", record);
            parameters.Add("track_view", false);
            string jsonData = CreateFormattedPostRequest("set_entry", parameters);
            var request = GetRestRequest(jsonData, "POST");
            var result = GetRestResponseByType<object>(request);
            return result.ToString();
        }
