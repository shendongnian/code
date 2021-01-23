    public List<Table> assignToTable(List<Person> invited, List<Table> tables)
    {
        if(!tables.HasRoom)
             return tables;
         else
         {
             assign(tables,invited) //code to add a person to a table
             assignToTable(invited, tables);
         }
    }
