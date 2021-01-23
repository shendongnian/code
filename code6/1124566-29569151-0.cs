    class UpdateStatement {
        public string TableName {get;set}
        public Dictionary<DataColumn, object> SetColumns {get;set;} // the object is the value to be updated
        public Dictionary<DataColumn, object> WhereColumns {get;set;} // the object here is the value that the column will be tested against in the where clause. 
    }
