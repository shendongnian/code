        /// <summary>
        /// Waits for a tag that matches a given criteria to show up on the page.
        /// 
        /// Note: This function returns a browser DOM element from the foreground thread, and this scraper is running in a background thread,
        /// so use an invoke [ scraperForm.Browser.Invoke(new Action(()=>{ ... })); ] when doing anything with the returned DOM element.
        /// </summary>
        /// <param name="tagName">The type of tag, or "" if all tags are to be searched.</param>
        /// <param name="id">The id of the tag, or "" if the search is not to be by id.</param>
        /// <paran name="className">The class name of the tag, or "" if the search is not to be by class name.</paran>
        /// <param name="keyContent">A string to search the tag's innerText for.</param>
        /// <returns>The first tag to match the criteria, or null if such a tag was not found after the timeout period.</returns>
        public HtmlElement WaitForTag(string tagName, string id, string className, string keyContent, int timeout) {
            Log(string.Format("WaitForTag('{0}','{1}','{2}','{3}',{4}) --", tagName, id, className, keyContent, timeout));
            HtmlElement result = null;
            int timeleft = timeout;
            while (timeleft > 0) {
                //Log("time left: " + timeleft);
                // Access the DOM in the foreground thread using an Invoke call.
                // (required by the WebBrowser control, otherwise cryptic errors result, like "invalid cast")
                scraperForm.Browser.Invoke(new Action(() => {
                    HtmlDocument doc = scraperForm.CurrentDocument;
                    if (id == "") {
                        //Log("no id supplied..");
                        // no id was supplied, so get tags by tag name if a tag name was supplied, or get all the tags
                        HtmlElementCollection elements = (tagName == "") ? doc.All : doc.GetElementsByTagName(tagName);
                        //Log("found " + elements.Count + " '" + tagName + "' tags");
                        // find the tag that matches the class name (if given) and contains the given content (if any)
                        foreach (HtmlElement element in elements) {
                            if (element == null) continue;
                            if (className != "" && !TagHasClass(element, className)) {
                                //Log(string.Format("looking for className {0}, found {1}", className, element.GetAttribute("className")));
                                continue;
                            }
                            if (keyContent == "" || 
                                (element.InnerText != null && element.InnerText.Contains(keyContent)) ||
                                (tagName == "input" && element.GetAttribute("value").Contains(keyContent)) ||
                                (tagName == "img" && element.GetAttribute("src").Contains(keyContent)) || 
                                (element.OuterHtml.Contains(keyContent)))
                            {
                                result = element;
                            }
                            else if (keyContent != "") {
                                //Log(string.Format("searching for key content '{0}' - found '{1}'", keyContent, element.InnerText));
                            }
                        }
                    }
                    else {
                        //Log(string.Format("searching for tag by id '{0}'", id));
                        // an id was supplied, so get the tag by id 
                        // Log("looking for element with id [" + id + "]");
                        HtmlElement element = doc.GetElementById(id);
                        // make sure it matches any given class name and contains any given content
                        if (
                            element != null 
                            && 
                            (className == "" || TagHasClass(element, className))
                            && 
                            (keyContent == "" || 
                                (element.InnerText != null && element.InnerText.Contains(keyContent))
                            )
                        ) {
                            // Log("  found it");
                            result = element;
                        }
                        else {
                            // Log("  didn't find it");
                        }
                    }
                }));
                if (result != null) break;   // the searched for tag appeared, break out of the loop 
                Thread.Sleep(200);           // wait for more milliseconds and continue looping 
                // Note: Make sure sleeps like this are outside of invokes to the foreground thread, so they only pause this background thread.
                timeleft -= 200;
            }
            return result;
        }
