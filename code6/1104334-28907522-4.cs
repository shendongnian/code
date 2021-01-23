    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        bool cancel = false;
        bool fireAgain = false;
        this.ComponentMetaData.FireInformation(0, "My sub", "info", string.Empty, 0, ref fireAgain);
        this.ComponentMetaData.FireError(0, "My sub", "error", string.Empty, 0, out cancel);
    }
