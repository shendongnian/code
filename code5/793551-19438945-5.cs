    protected override void OnShown(System.EventArgs e)
            {
                var formFontsResizeService = new FormFontsResizeService();
                formFontsResizeService.ResizeControlFonts(this);
            }
