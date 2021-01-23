    sb.Append("SELECT * FROM TABLE1 ");
    if (someCondition)
    {
        sb.Append("WHERE XColumn = @XColumn");
        myCommand.Parameters.AddWithValue("@XColumn", "SomeValue");
    }
    else
    {
        sb.Append("WHERE YColumn = @YColumn");
        myCommand.Parameters.AddWithValue("@YColumn", "SomeOtherValue");
    }
    myCommand.CommandText = sb.ToString();
          
