    //Create this object at class level
    public partial class AirlineReservation
    {
        SqlDataAdapter childDataAdapter;
    ...
    ...
     private void getData()
     {
         use it like this in getData() function
         childDataAdapter = new SqlDataAdapter("select * from Plane", connection);
         ...
         ...
    
    private void button2_Click(object sender, EventArgs e)
    {
    	DataRow[] row_update = ds.Tables["Plane"].Select("airline_id = " + aidbox.Text);
    	try
    	{
    		var row = row_update[0];
    		row["airline_id"] = int.Parse(aidbox.Text);
    		row["plane_id"] = int.Parse(pid_box.Text);
    		row["name"] = name_box.Text;
    		row["model"] = model_box.Text;
    		row["f_seats"] = int.Parse(fc_box.Text);
    		row["s_seats"] = int.Parse(sc_box.Text);
    		row["b_seats"] = int.Parse(bs_box.Text);
    		row["p_weight"] = float.Parse(weight_box.Text);
    	}
    	catch (Exception ex) { MessageBox.Show(ex.Message); }
    
    	try
    		{
    			builder = new SqlCommandBuilder(childDataAdapter);
                        //This line is not required
    			//data_adapter.UpdateCommand = builder.GetUpdateCommand();
                        ds.EndInit();
    			childDataAdapter.Update(ds, "Plane");
    
    		}
    		catch (SqlException ex) { MessageBox.Show(ex.Message); }
    	}
    
    }
