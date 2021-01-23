    public class MergeSpace
            {
                public List<Space> Mergespace(List<Space> Listofspaces)
                {
                  List<Space> mergedspacelist = new List<Space>();
                  int count=0;
                    foreach (Space space1 in Listofspaces)
                    {
                        foreach (Space space2 in Listofspaces)
                        {
                            //int count = 0;
                            if ((space1.sheight == space2.sheight)
                                && (space1.sdepth == space2.sdepth)
                                && (space2.xposition == space1.xposition + space1.slength)
                                && (space2.yposition == space1.yposition)
                                && (space2.zposition == space1.zposition)
                                && (space1.semptyspace == true)
                                && (space2.semptyspace == true))
                            {
                                Space space = new Space();
                               space.xposition = space1.xposition;
                                space.yposition = space1.yposition;
                                space.zposition = space1.zposition;
                                space1.slength = space1.slength + space2.slength;
                                space.sheight = space1.sheight;
                                space.sdepth = space1.sdepth;
                                space.semptyspace = true;
                                mergedspacelist .Add(space);   
                                count++;                         
                               
                            }
                    }
              }
              if(count>0)
             {
               Mergespace(mergedspacelist );
             }
    }
