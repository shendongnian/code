    con.Open();
    SqlCommand cmd1 = con.CreateCommand();
    SqlTransaction transaction1;
    transaction1 = con.BeginTransaction("Save Update Student");
    cmd1.Connection = con;
    cmd1.Transaction = transaction1;
    try
    {
        //sp to autogenerate student code in system..
        cmd1.CommandText = "sp_AutoGenerateStudentCode";
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.Add("@std", SqlDbType.VarChar).Value = cb_std.SelectedItem.ToString();
        cmd1.Parameters.Add("@div", SqlDbType.VarChar).Value = cb_div.SelectedItem;
        cmd1.Parameters.Add("@Rollno", SqlDbType.Int).Value = txt_roll.Text;
        cmd1.Parameters.Add("@ReturnValue", SqlDbType.VarChar).Value = txt_name.Text;
        cmd1.ExecuteNonQuery();
        cmd1.CommandType = CommandType.Text;
        cmd1.CommandText = "insert into StudentMaster(GrNo,Name,DOB,Std,Div,RollNo,MobileNo,Address,TelNo,FathersName,FathersProfession,MothersName,MothersProfession,Age,Year,status,DOE,BookNo,FeesStatus,FthrsQlfction,FthrsOfcAdd,FthrsPhone,MthrsPhone,MthrsOfcAdd,MthrsQlfction,Bloodgrp,caste,Nationality,MotherTongue,PreviousSchool,Religion,height,weight,sex,SCode,EmailId)values ('" + txt_Grno.Text + "','" + txt_name.Text + "',@DOB,'" + cb_std.SelectedItem + "','" + cb_div.SelectedItem + "','" + txt_roll.Text + "','" + txt_mobile.Text + "','" + Rtxt_ResiAdd.Text + "','" + txt_Phone.Text + "','" + txt_fname.Text + "','" + txt_fOccu.Text + "','" + txt_mName.Text + "','" + txt_mOccu.Text + "','" + txt_Age.Text + "',getDate(),'" + cb_status.SelectedItem + "',@DOE,'" + txt_bookno.Text + "','" + cb_feestat.SelectedItem + "','" + txt_fQualificatn.Text + "','" + Rtxt_fOfcAdd.Text + "','" + txt_fPhone.Text + "','" + txt_mPhone.Text + "','" + Rtxt_mOfcAdd.Text + "','" + txt_mQualificatn.Text + "','" + cb_BldGrp.SelectedItem + "','" + txt_caste.Text + "','" + txt_Nationality.Text + "','" + txt_MthrTng.Text + "','" + txt_PrevSchool.Text + "','" + txt_Relgn.Text + "','" + masktb_hgt.Text + "','" + masktb_wgt.Text + "','" + cb_Gender.SelectedItem + "','scode','" + txt_email.Text + "')";
 
        cmd1.Parameters.Add("@DOE", SqlDbType.DateTime).Value = dateTimePicker1.Value;
        cmd1.Parameters.Add("@DOB", SqlDbType.DateTime).Value = dateTimePicker2.Value;
        cmd1.ExecuteNonQuery();
        cmd1.CommandText = "PrimaryFeesMainUpdate";
        cmd1.ExecuteNonQuery();
        cmd1.CommandText = "FEE";
        cmd1.ExecuteNonQuery();
        
        // COMMIT THE TRANSACTION!        
        transaction1.Commit();
        con.Close();
        MessageBox.Show("Record Added Successfully", "Success");
        button2_Click(null, null);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
        Console.WriteLine("  Message: {0}", ex.Message);
        // Attempt to roll back the transaction. 
        try
        {
            transaction1.Rollback();
        }
        catch (Exception ex2)
        {
            Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
            Console.WriteLine("  Message: {0}", ex2.Message);
        }
    }
    con.Close();
