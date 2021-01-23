    [HttpPost]
    public ActionResult ComeFromAlabama(WithABanjoOnMyKnee vm){
        using(SqlConnection con = new SqlConnection(connectionString))
        using(SqlCommand com = new SqlCommand(con)) {
            con.Open();
            com.CommandText = "update Louisiana set Something=@Something where SomethingID=@SomethingID";
            com.CommandParameters.AddWithValue("@Something", vm.BuckwheatCake);
            com.CommandParameters.AddWithValue("@SomethingID", vm.SusannaID);
            com.ExecuteNonReader();
      }
      return RedirectResult("Index");
    }
