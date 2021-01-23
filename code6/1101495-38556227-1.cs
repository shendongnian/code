    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(memoryStream, true))
                            {
                                bool replacedAToken = true;
                                //continue to loop document until token's have not bee replaced.  This is because some tokens are spread across 'runs' and may need a second iteration of processing to catch them.
                                while (replacedAToken)
                                {
                                    //get all the text elements
                                    IEnumerable<Text> texts = wordDoc.MainDocumentPart.Document.Body.Descendants<Text>();
                                    replacedAToken = this.IterateTextsAndTokenReplace(texts, tokenNameValuePairs);
                                }
                                wordDoc.MainDocumentPart.Document.Save();
                                foreach (FooterPart footerPart in wordDoc.MainDocumentPart.FooterParts)
                                {
                                    if (footerPart != null)
                                    {
                                        Footer footer = footerPart.Footer;
                                        if (footer != null)
                                        {
                                            replacedAToken = true;
                                            while (replacedAToken)
                                            {
                                                IEnumerable<Text> footerTexts = footer.Descendants<Text>();
                                                replacedAToken = this.IterateTextsAndTokenReplace(footerTexts, tokenNameValuePairs);
                                            }
                                            footer.Save();
                                        }
                                    }
                                }
                                foreach (HeaderPart headerPart in wordDoc.MainDocumentPart.HeaderParts)
                                {
                                    if (headerPart != null)
                                    {
                                        Header header = headerPart.Header;
                                        if (header != null)
                                        {
                                            replacedAToken = true;
                                            while (replacedAToken)
                                            {
                                                IEnumerable<Text> headerTexts = header.Descendants<Text>();
                                                replacedAToken = this.IterateTextsAndTokenReplace(headerTexts, tokenNameValuePairs);
                                            }
                                            header.Save();
                                        }
                                    }
                                }
                            }
