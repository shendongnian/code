            var list = new ArrayList();
            new ArrayList();
            int toadd = 1;
            var newlst = new ArrayList();
            var str = new string[4];
            string strHeader = "";
            ArrayList lst = new ArrayList();
            int shapeCount = 0;
            foreach (object item in presentation.Slides[slideIndex].Shapes) //get all objects in all slides
                {
                int bulletCount = 0;
                int paragraphCount=0;
                    var shape = (Microsoft.Office.Interop.PowerPoint.Shape)item;
                    if (shape.HasTextFrame == MsoTriState.msoTrue)
                    {
                        if (shape.HasTextFrame == MsoTriState.msoTrue)
                        {
                            shapeCount +=1;
                            if (shapeCount == 1)
                            {
                                strHeader = shape.TextFrame.TextRange.Text;
                            }
                            Microsoft.Office.Interop.PowerPoint.TextFrame2 textFrame = shape.TextFrame2;
                            TextRange2 textRange = textFrame.TextRange;
                            TextRange2 ps = textRange.Paragraphs;
                            paragraphCount = ps.Count;
                            for (int bullet = 1; bullet <= paragraphCount; bullet++)
                            {
                                BulletFormat2 bulletFormat2 = ps.Item(bullet).ParagraphFormat.Bullet;
                                if (bulletFormat2.Type != MsoBulletType.msoBulletNone)
                                {
                                    //this paragraph has has bullet
                                    bulletCount++;
                                    //MessageBox.Show( ps.Item(i).Text);
                                    if (bulletCount > 4)
                                    {
                                        //create new slide, cut this paragraph and paste in the new slide
                                        list.Add(ps.Item(bullet).Text);
                                    }
                                    newlst.Add(ps.Item(bullet).Text);
                                    lst.Add(ps.Item(bullet).Text);
                                }
                            }
                        }
                    }
                   
                }
                int slideCounter = 0;
                if (newlst.Count <= 4)
                {
                    newlst.Clear();
                }
                else
                {
                   // strHeader = newlst[0].ToString();
                    newlst.CopyTo(0, str, 0, 4);
                    AddNewPptSlide(presentation, slideIndex + toadd, str, strHeader,0,_standard); // adding new slide
                    toadd += 1;
                    str[0] = "";
                    str[1] = "";
                    str[2] = "";
                    str[3] = "";
                    slideCounter = slideCounter + 1;
                }
                if (list.Count > 0)
                {
                    int xx = 0;
                    for (int x = 0; xx < list.Count; x++)
                    {
                        str[x] = list[xx].ToString();
                        if (x == 3)
                        {
                            AddNewPptSlide(presentation, slideIndex + toadd, str, strHeader, 1, _standard); // adding new slide
                            toadd += 1;
                            slideCounter = slideCounter + 1;
                            str[0] = "";
                            str[1] = "";
                            str[2] = "";
                            str[3] = "";
                            x = -1;
                        }
                        xx++;
                    } //End for (int x = 0; xx < list.Count; x++)
                    if (list.Count % 4 != 0)
                    {
                        AddNewPptSlide(presentation, slideIndex + toadd, str, strHeader, 1, _standard); // adding new slide
                        toadd += 1;
                    } // if (list.Count%4!= 0)
                } //if(list.Count>0)
                newlst.Clear();
                list.Clear(); //clear ArrayList
                strHeader = "";
                if (lst.Count > 4)
                {
                    presentation.Slides[slideIndex].Delete();
                }
            }
