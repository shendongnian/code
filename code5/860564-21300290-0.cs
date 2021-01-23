    public partial class spc_aspEntities
    {
        public List<Models.ProgramMenu> GetMenuForUser(string userLoginId)
        {
            // existing code to get USER_LEVEL..
            // create a single query to get your full menu structure
            // your EF model should already include the relationship 
            // between PROGRAM_TB and GROUP_AUTH_TB
            var query = this.PROGRAM_TB
                .Where(p => p.PROGRAM_GB == TOP_MENU_TYPE)
                .OrderBy(p => p.PROGRAM_ORDER)
                .Select(p => new {
                    p.PROGRAM_ID, 
                    p.PROGRAM_NAME,
                    // assuming there's also a relationship defined
                    // between PROGRAM_TB and itself on 
                    // PROGRAM_SYSTEM == (parent).PROGRAM_NAME
                    SubMenus = p.ChildPrograms
                        .Where(cp => cp.PROGRAM_GB == SUB_MENU_TYPE)
                        .Where(cp => cp.GroupAuths
                            .Any(g => g.GROUP_ID == userGroupId 
                                && g.OPEN_YN == "True"
                            )
                        )
                        .Select(cp => new { cp.PROGRAM_ID, cp.PROGRAM_NAME })
                });
                // now project this into your model, ToList() forces the query to run so
                // we can then perform non-sql manipulation (like newing up objects etc)
                var programMenuList = query.ToList()
                    .Select(anon => new Models.ProgramMenu(
                        anon.PROGRAM_ID, 
                        anon.PROGRAM_NAME, 
                        anon.SubMenus.Select(sub => new Models.ProgramSubMenu(
                            sub.PROGRAM_ID, 
                            sub.PROGRAM_NAME
                        ).ToList()
                    )).ToList();
                return programMenuList;
        }
    }
