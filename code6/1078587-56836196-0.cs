            MySqlDataAdapter daAll = new MySqlDataAdapter("Select * from courses;Select * from productsku;Select * from productcourseassociation;", sqlConn);
            MySqlDataAdapter daCourses = new MySqlDataAdapter("Select * from courses;", sqlConn);
            MySqlDataAdapter daSku = new MySqlDataAdapter("Select * from productsku;", sqlConn);
            MySqlDataAdapter daAssoc = new MySqlDataAdapter("Select * from productcourseassociation;", sqlConn);
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
            DataRow r = ds.Tables[0].NewRow();
        r["coursename"] = courseName;
        ds.Tables[0].Rows.Add(r);
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
        //Clear and refill because autoincrement values when actually written to the database may be different and not reflected in the updated row in the ds
        ds.Clear();
        daCourses.Fill(ds, "Table");
        daSku.Fill(ds, "Table1");
        daAssoc.Fill(ds, "Table2");
        DataRow[] courserows = ds.Tables[0].Select(String.Format("coursename='{0}'", courseName));
        int courseId = Convert.ToInt32(courserows[0]["courseid"]);
        DataRow[] skurows = ds.Tables[1].Select(String.Format("skudesc='{0}'", courseName));
        foreach (DataRow dr in skurows)
        {
            r = ds.Tables[2].NewRow();
            r["skuid"] = dr["skuid"];
            r["courseid"] = courseId;
            ds.Tables[2].Rows.Add(r);
        }
        daAssoc.Update(ds, "Table2");
