    var codeParameter = new OracleParameter(
    "code", OracleType.Int32, 4, "code");
    codeParameter.Value = Convert.ToInt32(dept_cod_txt.Text);
    var nameParameter = new OracleParameter(
    "name", OracleType.NVarchar, 20, "name");
    nameParameter.Value = dept_name_txt.Text;
    com.Parameters.Add(codeParameter);
    com.Parameters.Add(nameParameter);
 
