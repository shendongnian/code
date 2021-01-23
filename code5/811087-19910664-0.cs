    Dim Dobbel(6) as integer
    Dim RandomNumber as new Random
    for (int = 0; i < 5; i++)
    {
    	Dobbel(i) = RandomNumber.Next(1, 6)
    }
     
    For Each i As Integer In Dobbel
    {
            Select Case Dobbel(i)
                Case 1
                    Steen(i).Image = Game.My.Resources.Een
    
                Case 2
                    Steen(i).Image = Game.My.Resources.Twee
    
                Case 3
                    Steen(i).Image = Game.My.Resources.Drie
    
                Case 4
                    Steen(i).Image = Game.My.Resources.Vier
    
                Case 5
                    Steen(i).Image = Game.My.Resources.Vijf
    
                Case 6
                    Steen(i).Image = Game.My.Resources.Zes
    
            End Select
    }
