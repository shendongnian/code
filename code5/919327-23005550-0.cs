    OtherUserInformation userData = db.Users.Where(u => u.UserID.Equals(inputUserid)).Select(x => new OtherUserInformation
                        {
                            Address = x.location == null ? "" : x.location,
                           // UserPic = Utilities.ImagePathForProfileForUserByDiviceType(db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.profileImg).FirstOrDefault(),deviceType),
                           // CoverPic = Utilities.ImagePathForCoverImageForUserByDiviceType(db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.CoverImg).FirstOrDefault(), deviceType),
                            UserPic = db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.profileImg).FirstOrDefault() == null ? profileImagePath + "140_profile_default.jpg" : profileImagePath + "140_" + db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.profileImg).FirstOrDefault(),
                            CoverPic = db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.CoverImg).FirstOrDefault() == null ? coverImagePath + "812_cover_default.jpg" : coverImagePath + coverPicPrefix + db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.CoverImg).FirstOrDefault(),
                            Detail = db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).Select(y => y.About).FirstOrDefault() == null ? "" : db.UserProfile.Where(u => u.UserID.Equals(x.UserID)).AsEnumerable().Select(y => WebUtility.HtmlDecode(y.About)).FirstOrDefault(),
                            FollowerCount = db.FollowUser.Where(u => u.FriendId.Equals(x.UserID) && u.FollowStatus.Equals(1)).Count(),
                            Name = x.FirstName + " " + x.LastName,
                            IsFollow = db.FollowUser.Where(u => u.UserId.Equals(userAuthInfo.UserId) && u.FriendId.Equals(inputUserid) && u.FollowStatus.Equals(1)).Select(z => z).FirstOrDefault() == null ? "False" : "True",
                            })
                        }).FirstOrDefault();
