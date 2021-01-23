    private DataTable table;
    public IEnumerable<Model> DCResults {
        get {
            //do something to get datatable
            foreach(var row in table.Rows){
                yield return new Model(){
                    //initialize values
                };
            }
        }
    }
