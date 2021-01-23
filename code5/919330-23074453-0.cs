                            Address = x.Address,
                            UserPic = x.UserPic,
                            CoverPic = x.CoverPic,
                            Detail = Regex.Replace(x.Detail, "<.*?>", string.Empty),
                            FollowerCount = x.FollowerCount,
                            Name = x.Name,
                            IsFollow = x.IsFollow,
                            Categories = x.Categories,
                            Followers = x.Followers
                        }).FirstOrDefault();
