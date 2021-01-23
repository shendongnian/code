                 @for (int i = 0; i < Model.RelatedUnresolvedDefects.Count(); i++ )
                            {
                                <tr>
                                    <td>
                                        @Html.EditorFor(x => Model.RelatedUnresolvedDefects[i].IsSameDefect)
                                    </td>
                                </tr>
                            }
