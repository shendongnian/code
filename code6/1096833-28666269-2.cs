    string query = "fulname_kkkkk";
    // var result  = from tableA in ContextDB.tblA
    //              join tableB in ContextDB.tblb tableA. ID equals tableB.ID
    //              select tableA;
    //
    //String.isNullOrEmpty(query)
    if (!String.IsNullOrEmpty (query)) {
        if (query.Contains (".")) {
    	    Console.WriteLine ("Contains .");
    //                  var names = fullName.Split ('.');
    //                  string fName = names[0];
    //                  string lName = names[1];
    //                  result = result.where(p => p.FirstName.containe(fName) || p.LastName.containe(lName));
	
		} else if (query.Contains ("_")) {
		    Console.WriteLine ("Contains _");
	//                      var names = fullName.Split ('_');
	//                      string fName = names[0];
	//                      string lName = names[1];
	//                      result = result.where(p => p.FirstName.containe(fName) || p.LastName.containe(lName));
	    } else if (query.Contains (" ")) {
		    Console.WriteLine ("Contains ");
					//var names = fullName.Split ('_');
					//string fName = names[0];
					//string lName = names[1];
					//result = result.where(p => p.FirstName.containe(fName) || p.LastName.containe(lName));
		} else {
			Console.WriteLine ("fullname ");
			//result = result.where(p => p.FirstName.containe(query) || p.LastName.containe(query));
		}
		} else {
			Console.WriteLine("Exiting program");
		}
