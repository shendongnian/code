    private void Start()
    {
        while(true) {
            // run select query
            mysql(selectQueryString.ToString());
            msdr = mysql();
            // is finished
            if (!msdr.HasRows)
            {
                this.Finish();
                break;
            }
            //  rest of your code..
        }
    }
