    using (var carcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BeravaConnectionString"].ConnectionString)))
    {
        if (cookie != null)
        {
            // Parameters for SQL
            var parameters = new Dictionary<string, object>();
            // string builder to build up SQL Statement
            var CarSqlST = new StringBuilder(
                "SELECT DISTINCT AdsID, Section, Category, Country, Maker, Gear, Condition, Status, State, City, AdsTit, " +
                "SUBSTRING(AdsDesc,1,155) as AdsDesc, Year, AdsPrice, Img1 From ads " +
                "Where Category = @pCATE AND Country = @pLocation ");
            parameters.Add("@pCATE", Request.QueryString["cat"].ToString());
            parameters.Add("@pLocation", cookie["Location"]);
            if (barndcardrlst.SelectedValue != "")
            {
                CarSqlST.Append(" and Maker= @pMaker");
                parameters.Add("@pMaker", barndcardrlst.SelectedValue);
            }
            if (GearDrDw.SelectedValue != "")
            {
                CarSqlST.Append(" and Gear= @pGear");
                parameters.Add("@pGear", GearDrDw.SelectedValue);
            }
            if (carstatedrdolst.SelectedValue != "")
            {
                CarSqlST.Append(" and State= @pState");
                parameters.Add("@pState", carstatedrdolst.SelectedValue);
            }
            if (citiesdrdolst.SelectedValue != "")
            {
                CarSqlST.Append(" and State= @pCity");
                parameters.Add("@pCity", citiesdrdolst.SelectedValue);
            }
            if (CarCondDrDw.SelectedValue != "")
            {
                CarSqlST.Append(" and Condition= @pCondition");
                parameters.Add("@pCondition", CarCondDrDw.SelectedValue);
            }
            if (CarstusDRDL.SelectedValue != "")
            {
                CarSqlST.Append(" and Status= @pStatus");
                parameters.Add("@pStatus", CarstusDRDL.SelectedValue);
            }
            if ((CarPriceFrmDrDw.SelectedValue != "") && (CarPriceToDrDw.SelectedValue != ""))
            {
                CarSqlST.Append(" and AdsPrice BETWEEN @pLowPrice AND @pHighPrice");
                parameters.Add("@pLowPrice", CarPriceFrmDrDw.SelectedValue);
                parameters.Add("@pHighPrice", CarPriceToDrDw.SelectedValue);
            }
            if ((CarYearfrmDrDw.SelectedValue != "") && (CarYeartoDrDw.SelectedValue != ""))
            {
                CarSqlST.Append(" and Year BETWEEN @pLowYear AND @pHighYear");
                parameters.Add("@pLowYear", CarYearfrmDrDw.SelectedValue);
                parameters.Add("@pHighYear", CarYeartoDrDw.SelectedValue);
            }
            DataTable cdt = new DataTable();
            SqlCommand ccmd = carcon.CreateCommand();;
            ccmd.CommandType = CommandType.Text;
            // Add all the parameters into this command
            foreach (var parameter in parameters)
            {
                ccmd.Parameters.Add(parameter.Key, parameter.Value);
            }
            // set the command text from string builder
            ccmd.CommandText = CarSqlST.ToString();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = ccmd;
        }
    }
