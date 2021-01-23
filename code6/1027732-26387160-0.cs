    using (MySql.Data.MySqlClient.MySqlConnection cn = new   
    MySql.Data.MySqlClient.MySqlConnection(
                Properties.Settings.Default.CONNNConnectionString))
    {
    	cn.Open();
    	MySql.Data.MySqlClient.MySqlCommand cm = new 
    	MySql.Data.MySqlClient.MySqlCommand();
    	cm.CommandType = CommandType.Text;
    	cm.Connection = cn;
    	cm.CommandText=@"
    	DELIMITER //
    	 CREATE PROCEDURE GetMovement(IN RefArtt VARCHAR(20), IN idos INTEGER)
    	   BEGIN
    		SELECT * 
    		FROM tableInOut 
    		WHERE ref = RefArtt AND id = idos;
    	   END //
    	DELIMITER ;	
    	";
    	cm.ExecuteNonQuery();
    }
