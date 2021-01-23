    var arr = from m in m_Repo.All().AsEnumerable()
                              .Where(a => a.Status == Completed && a.ID== 12 && a.IsDeleted == false)
                          group m by new { m.Name } into g
                          select g.OrderByDescending(gg => gg.UpdatedAt).Take(1)
                           .Where(dd => dd.Type == true).First();
