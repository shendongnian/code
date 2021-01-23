    if (currLink.GetAttributeValue("name").Contains("page"))
                        {
                            _firstPartOfAddress = currLink.Url.Substring(0, nextPageUrl.Length);
                            tmpUrl = currLink.Url.Remove(0,nextPageUrl.Length);
                            _lastPartOfAddress = tmpUrl.Substring(tmpUrl.IndexOf("?"));
                            tmpUrl = tmpUrl.Substring(0,tmpUrl.IndexOf("?"));
                            int.TryParse(tmpUrl, out currentpageCounter);
                            if (currentpageCounter > _maxPageCounter)
                            {
                                _maxPageCounter = currentpageCounter;
                                currentpageCounter = 0;
                            }
                        }
    
