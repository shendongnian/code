    System.Data.DataTable table = ...;
    table.ApplyColumnFormatting("Column_Name",
        () => { /* Apply DateTime formatting here */ },
        () => { /* Apply Numeric formatting here */ }
    );
