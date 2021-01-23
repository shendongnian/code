    {
    	MySqlDataAdapter daAll = new MySqlDataAdapter("Select * from courses;Select * from productsku;Select * from productcourseassociation;", sqlConn);
    	MySqlDataAdapter daCourses = new MySqlDataAdapter("Select * from courses;", sqlConn);
    	MySqlDataAdapter daSku = new MySqlDataAdapter("Select * from productsku;", sqlConn);
    	MySqlDataAdapter daAssoc = new MySqlDataAdapter("Select * from productcourseassociation;", sqlConn);
    	daCourses.RowUpdated += DaCourses_RowUpdated;
    	daSku.RowUpdated += DaSku_RowUpdated;
    	DataSet ds = new DataSet();
    	daAll.FillSchema(ds, SchemaType.Source);
    
    	daCourses.TableMappings.Add("courses", "Table");
    	daSku.TableMappings.Add("productsku", "Table1");
    	daAssoc.TableMappings.Add("productcourseassociation", "Table2");
    	ForeignKeyConstraint fkConstraint1 = new ForeignKeyConstraint("fk1", ds.Tables[0].Columns["courseid"], ds.Tables[2].Columns["courseid"]);
    	ForeignKeyConstraint fkConstraint2 = new ForeignKeyConstraint("fk2", ds.Tables[1].Columns["skuid"], ds.Tables[2].Columns["skuid"]);
    	ds.Tables[2].Constraints.Add(fkConstraint1);
    	ds.Tables[2].Constraints.Add(fkConstraint2);
    
    	MySqlCommandBuilder cbCourses = new MySqlCommandBuilder(daCourses);
    	MySqlCommandBuilder cbSku = new MySqlCommandBuilder(daSku);
    	MySqlCommandBuilder cbAssoc = new MySqlCommandBuilder(daAssoc);
    
    	DataRow courseRow = ds.Tables[0].NewRow();
        courseRow["coursename"] = courseName;
        ds.Tables[0].Rows.Add(courseRow);
    
        r = ds.Tables[1].NewRow();
        r["skudesc"] = courseName;
        r["duration"] = 1;
        ds.Tables[1].Rows.Add(r);
    
        r = ds.Tables[1].NewRow();
        r["skudesc"] = courseName;
        r["duration"] = 3;
        ds.Tables[1].Rows.Add(r);
    
        r = ds.Tables[1].NewRow();
        r["skudesc"] = courseName;
        r["duration"] = 12;
        ds.Tables[1].Rows.Add(r);        
    
        daCourses.Update(ds, "Table");
        daSku.Update(ds, "Table1");		
        daAssoc.Fill(ds, "Table2");
    	        
        int courseId = Convert.ToInt32(courseRow["courseid"]);
        DataRow[] skurows = ds.Tables[1].Select(String.Format("skudesc='{0}'", courseName));
        foreach (DataRow dr in skurows)
        {
            r = ds.Tables[2].NewRow();
            r["skuid"] = dr["skuid"];
            r["courseid"] = courseId;
            ds.Tables[2].Rows.Add(r);
        }
        daAssoc.Update(ds, "Table2");
    }	
    	
    private void DaSku_RowUpdated(object sender, MySqlRowUpdatedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Row updated");
        e.Row["skuid"] = e.Command.LastInsertedId;
    }
    
    private void DaCourses_RowUpdated(object sender, MySqlRowUpdatedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Row updated");
        e.Row["courseid"] = e.Command.LastInsertedId;
    }		
