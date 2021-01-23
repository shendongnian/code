    for (i = 0; i < 40; i++)
    {
        var panel = this.Controls
            .OfType<Panel>()
            .First(p => p.Name == string.Format("panel{0}"))
        var label = this.Controls
            .OfType<Label>()
            .First(p => p.Name == string.Format("label{0}"));
        var panel = this.Controls
            .OfType<PictureBox>()
            .First(p => p.Name == string.Format("pictureBox{0}"));
        myFunction(panel, label, pictureBox);
    }
