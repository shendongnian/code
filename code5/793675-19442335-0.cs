            NameValueCollection  coll;
            coll = new NameValueCollection();
            coll.Add("REMOTE_USER", "Tom");
            coll.Add("REMOTE_USER", "Dick");
            coll.Add("REMOTE_USER", "Harry");
            LoginStatue1.Text =  string.Format("1st=({0}),2nd=({1}),3rd=({2})", coll.GetValues("REMOTE_USER")[0],  (string) coll["REMOTE_USER"], coll.GetValues("REMOTE_USER")[0]);
