                switch (oColumn.Header.ToString().ToLowerInvariant())
                {
                    case "id":
                        oColumn.CellStyle = (Style)Resources["CellRightAlign"];
                        oColumn.Header = "Identifier";
                        break;
