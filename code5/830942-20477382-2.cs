    {
        /*
         * put the try at the top of the block to catch exceptions
         * that may occur before you bind the GridView's datasource
         */
        try
        {
            numo = DropDownList1.SelectedValue;
            string valor = "%" + TextBox1.Text.Replace(" ", "%") + "%"; // no reason to NOT one-line this
    
            /*
             * This would probably be easier to maintain if DropDownList1
             * was bound to an enumeration of these values:
             *     DataTextField="someTextField"
             *     DataValueField="someCorrespondingNumericField"
             * If bound that like above, your switch statement becomes:
             *     Integer.Parse(DropDownList1.SelectedValue, numo);
             * and numo then contains 1, 2, 3, or 4 thus eliminating the need for the variable num3.
             */
            switch (numo)
            { 
                case "Nome":
                    num3 = 1;
                    break;
                case "Endereço":
                    num3 = 2;
                    break;
                case "Telefone":
                    num3 = 3;
                    break;
                case "Pedido":
                    num3 = 4;
                    break;
            }
    
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "cazacliente2";
    
            // add parameters and set values all at once
            cmd.Parameters.Add("@vbusca", SqlDbType.NVarChar, 60).Value = valor;
            cmd.Parameters.Add("@bo",SqlDbType.Int).Value = num3;
    
            if (conex1.State == ConnectionState.Closed)
            {
                conex1.Open();
            }
            cmd.Connection = conex1;
    
            GridView1.EmptyDataText = "Nao se " + numo.ToString()  +" encontraron registros";
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conex1.Close();
        }
    }
