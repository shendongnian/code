    public void Delete(Example example)
    {
        db.Examples.ExecuteSqlCommand("exec usp_DeleteExample @ExampleID", 
            new SqlParameter("@ExampleID", example.ExampleID)
        );
        return;
    }
