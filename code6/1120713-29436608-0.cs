     var selectedCoursesHS = new HashSet<string>(selectedCourses);
                var instructorCourses = new HashSet<int>
                    (instructor.Courses.Select(c => c.CourseID));
                foreach (var course in schoolContext.Courses)
                {
                    if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                    {
                        if (!instructorCourses.Contains(course.CourseID))
                        {
                            instructor.Courses.Add(course);
                        }
                    }
                    else
                    {
                        if (instructorCourses.Contains(course.CourseID))
                        {
                            instructor.Courses.Remove(course);
                        }
                    }
                }
