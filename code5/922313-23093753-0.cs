            var dbe = new DBEngine();
            var db = dbe.OpenDatabase(@"c:\path\to\your\youraccessdatabase.accdb");
            // loop over tables
            foreach (TableDef t in db.TableDefs)
            {
                // create a querydef
                var qd = new QueryDef();
                qd.Name = String.Format("Count for {0}", t.Name);
                qd.SQL = String.Format("SELECT count(*) FROM {0}", t.Name);
                //append the querydef (it will be parsed!)
                // might throw if sql is incorrect
                db.QueryDefs.Append(qd);
            }
            
            db.Close();
