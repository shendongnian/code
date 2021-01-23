    SqlCeCommand command = new SqlCeCommand("UPDATE Bio SET text = @htmlText WHERE id = @id", conn);
    SqlCeParameter param;
    // NOTE:
    // For optimal performance, make sure you always set the parameter
    // type and the maximum size - this is especially important for non-fixed
    // types such as NVARCHAR or NTEXT; In case of named parameters, 
    // SqlCeParameter instances do not need to be added to the collection
    // in the order specified in the query; If however you use ? as parameter
    // specifiers, then you do need to add the parameters in the correct order
    //
    param = new SqlCeParameter("@id", SqlDbType.Int);
    command.Parameters.Add(param);
    param = new SqlCeParameter("@htmlText", SqlDbType.NVarChar, -1);
    command.Prepare();
    //Set the values and the length of the string parameter
    command.Parameters[0].Value = ViewBag.Id;
    command.Parameters[1].Value = form["textbox"];
    command.Parameters[1].Size = form["textbox"].Length;
    // Execute the SQL statement
    //
    command.ExecuteNonQuery();
