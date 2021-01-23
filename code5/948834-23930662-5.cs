     [Test] 
     public void ThatTheIpIsNotHighlightedIfTheListWasCleared()
     {
        UniformGridHighlighting.HighlightIP("1.1.1.1");
        //Act
        UniformGridHighlighting.ClearIPHighlighting();
        UniformGridHighlighting.Highlihst(Grid);
        //Assert:
        //Go through the grid to figure out that the IP was not highlighted. The below is a total guess:
        bool wasHighlighted = Grid.Rows.Any(row => row.Cells.Any(Cell.Highlighted));
        Assert.Isfalse(wasHighlighted);
     }
