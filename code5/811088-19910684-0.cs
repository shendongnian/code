    For Each pb As PictureBox In New PictureBox() {steen1, steen2, steen3, steen4, steen5, steen6}
      Select Case RandomNumber.Next(1, 7)
        Case 1 : pb.Image = Game.My.Resources.Een
        Case 2 : pb.Image = Game.My.Resources.Twee
        Case 3 : pb.Image = Game.My.Resources.Drie
        Case 4 : pb.Image = Game.My.Resources.Vier
        Case 5 : pb.Image = Game.My.Resources.Vijf
        Case 6 : pb.Image = Game.My.Resources.Zes
      End Select
    Next
