    using(var db = new MyEntities(){ 
      string Query = "Select XYZ from Tablea,TableB where something=@parm";      
      SqlParameter[] parms = {new SqlParameter{name = "parm" value="somevalue");       
      var stuff = db.Database.SQLQuery<MyModel>(query, parms.ToArray());
      return stuff.ToList();
    }
