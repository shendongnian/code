    QueryScheduleRequest scheduleRequest = new QueryScheduleRequest
                    {
                        ResourceId = userResponse.UserId,
                        Start = DateTime.Now,
                        End = DateTime.Today.AddDays(7),
                        TimeCodes = new TimeCode[] { TimeCode.Unavailable }
                    };
                    QueryScheduleResponse scheduleResponse = (QueryScheduleResponse)_orgService.Execute(scheduleRequest);
