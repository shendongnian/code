    string query = @"<View Scope='RecursiveAll'><Query><Where>
                                                    <And>
                                                            <Eq>
                                                                <FieldRef Name='FSObjType' />
                                                                <Value Type='Text'>1</Value>
                                                            </Eq>
                                                            <Eq>
                                                                <FieldRef Name='FileRef' />
                                                                <Value Type='Text'>{0}</Value>
                                                            </Eq>
                                                    </And>
                                                </Where></Query></View>";
