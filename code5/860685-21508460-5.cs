    [DirectMethod]
    public void DeleteSelected(int[] idArray)
    {
        ctx.ExecuteCommand(
            string.Format(
                "DELETE FROM Employees WHERE ID IN ({0})",
                string.Join(",", idArray.Select(x => x.ToString()).ToArray())
            )
        );
    }
