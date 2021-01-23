    public void SymbolReader_ReadNotify(object sender, EventArgs e)
                {
                    Symbol.Barcode.ReaderData TheReaderData = Scanner.SymbolReader.GetNextReaderData();
                    if (TheReaderData.Result == Symbol.Results.SUCCESS && (txtBarcode.Focused == true))
                    {
                        if (txtBarcode.Focused == true)
                        {
                            txtBarcode.Text = TheReaderData.Text.ToString();
                           Scanner.SymbolReader.Actions.Read(Scanner.SymbolReaderData);
                            return;
                        }
                    }
                    Scanner.SymbolReader.Actions.Read(Scanner.SymbolReaderData);
                }
