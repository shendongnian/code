    var someViewModel = _repository.Table.Where(x => x.Id == someId)
                        .Select(new ListViewModel()
                                {
                                    GroupId = x.Group.Id,
                                    GroupTitle = x.Group.Title
                                    List = new List<SubViewModel> { new SubViewModel(x) }
                                });
