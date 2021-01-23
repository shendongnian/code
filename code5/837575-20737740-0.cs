    if (t == ARF.Rows.Count)
                                {
                                    for (int s = 0; s < ARF.Rows.Count; s++)
                                    {
                                        Chart1.Legends.Add(new Legend("Legends1" + s.ToString()));
                                        Chart1.Series["Series1" + s.ToString()].Legend = "Legends1" + s.ToString();
                                        Chart1.Legends["Legends1" + s.ToString()].DockedToChartArea = "ChartArea1" + s.ToString();
                                    }
                                }
