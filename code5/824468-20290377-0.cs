    DateTime ucode = DateTime.Now;
    string slctedProj = DropDownList1.SelectedItem.ToString();
    string new_code = "PR" + ucode.ToString("ssmmHHddMM");
    string new_projectName = "Some new name";
    
    string query = @"INSERT INTO Projects (proj_id, proj_prod_id, proj_cust_id, proj_man_id,
                    proj_name, proj_date, proj_num_of_vehicles, proj_coach_vehicle,
                    proj_contract_value, proj_length, proj_width, proj_height, proj_passenger_seats,
                    proj_passenger_total, proj_type, proj_notes, uname, proj_brand, proj_systemvoltage,
                    proj_gauge, proj_service_speed)
                    SELECT @NewProjectID, proj_prod_id, proj_cust_id, proj_man_id,
                    @NewProjectName, proj_date, proj_num_of_vehicles, proj_coach_vehicle,
                    proj_contract_value, proj_length, proj_width, proj_height, proj_passenger_seats,
                    proj_passenger_total, proj_type, proj_notes, uname, proj_brand, proj_systemvoltage,
                    proj_gauge, proj_service_speed
                    FROM Projects WHERE proj_name = @SelectedProj";
                    
    System.Windows.Forms.MessageBox.Show(query);
       
    string getconnstring = ConfigurationManager.ConnectionStrings["stad_conn"].ConnectionString;
    SqlConnection conn = new SqlConnection(getconnstring);
    conn.Open();
    SqlCommand cmd = new SqlCommand(query, conn);
    cmd.Parameters.Add("@NewProjectID", SqlDbType.VarChar, 20).Value = new_code;
    cmd.Parameters.Add("@NewProjectName", SqlDbType.VarChar, 20).Value = new_projectName;
    cmd.Parameters.Add("@SelectedProj", SqlDbType.VarChar, 20).Value = slctedProj;
    
    cmd.ExecuteNonQuery();
    conn.Close();
