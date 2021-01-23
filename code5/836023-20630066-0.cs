    for (int y = 0; y < 255; y++)
            {
                color = new Color((255), y, y);
                for (int z = 0; z < 6; z++)
                {
                    for (int x = 0; x < 255; x++)
                    {
                        float colorDif = (255 / ((float)255 - y));
                        uint ux = (uint)x;
                        uint uy = (uint)y;
                        uint uz = (uint)z;
                        ux = ux + (uz * 255);
                        image.SetPixel(ux, uy, color);
                        if (x >= lastX + colorDif)
                        {
                            //Red 255 - Green 0-254
                            if (z == 0)
                            {
                                if (color.G < (255))
                                    color.G += 1;
                            }
                            //Green 255 - Red 255-0
                            else if (z == 1)
                            {
                                if (color.R > y)
                                    color.R -= 1;
                            }
                            //Green 255 - Blue 0-255
                            else if (z == 2)
                            {
                                if (color.B < (255))
                                    color.B += 1;
                            }
                            //Blue 255 - Green 255-0
                            else if (z == 3)
                            {
                                if (color.G > y)
                                    color.G -= 1;
                            }
                            //Blue 255 - Red 0-255
                            else if (z == 4)
                            {
                                if (color.R < (255))
                                    color.R += 1;
                            }
                            //Red 255 - Blue 255-0
                            else if (z == 5)
                            {
                                if (color.B > y)
                                    color.B -= 1;
                            }
                            lastX += colorDif;
                        }
                    }
                    lastX = 0;
                }
            }
