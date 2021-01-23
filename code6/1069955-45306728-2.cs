        public event EventHandler<CodeGenEventArgs> CodeGenClick;
            private void CodeGenClickAsync(CodeGenEventArgs args)
        {
            CodeGenClick.InvokeAsync(this, args, ar =>
            {
                InvokeUI(() =>
                {
                    if (args.Code.IsNotNullOrEmpty())
                    {
                        var oldValue = (string) gv.GetRowCellValue(gv.FocusedRowHandle, nameof(License.Code));
                        if (oldValue != args.Code)
                            gv.SetRowCellValue(gv.FocusedRowHandle, nameof(License.Code), args.Code);
                    }
                });
            });
        }
