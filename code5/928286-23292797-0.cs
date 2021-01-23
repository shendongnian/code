    var list = _entities.People
                .Where(item => item.Skill.SkillName == q && 
                               item.StateId == s && 
                               item.LGAId == l && 
                               item.Ratings.Any(g => g.RatingValue == z))
                .ToList()
                .GroupBy(item => new 
                {
                    item.PersonId,
                    item.LastName,
                    item.Skill.SkillName,
                    item.StateId,
                    item.LGAId,
                    item.Address,
                    item.Email,
                    item.ImageSource,
                    item.RegDate
                })
                .Select(d => new PersonVm() 
                {
                    PersonId = d.Key,
                    Rating = d.Average(x => x.Ratings.Any(y => y.RatingValue)),
                    LastName = d.Key.LastName,
                    Skill = d.Key.SkillName,
                    StateId = d.Key.StateId,
                    LGAId = d.Key.LGAId,
                    Address = d.Key.Address,
                    Email = d.Key.Email,
                    ImageSource = @"\Photos\" + d.Key.ImageSource,
                    RegDate = d.Key.RegDate
                })
                .ToList();
