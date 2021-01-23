       <div class="col-lg-12">
                @Html.Grid(@Model.OrderBy(i=>i.Sequence)).Columns(columns =>
                                            {
                                                
                                                if (columns != null)
                                                {
                                                    columns.Add(c => c.Sequence).Titled("SEQUENCE").Filterable(true);
                                                    columns.Add(c => c.Desc).Titled("DESC").Filterable(true);
                                                    columns.Add().Titled("Oportunity")
                                                        .Encoded(false).Sanitized(false).SetWidth(10).RenderValueAs(m =>
                                                            @<b>
                                                                  @Html.TextArea("txt_Oportunity"+m.Id, "", new {@class = "form-control"})
                                                            </b>);
                                                    columns.Add().Titled("")
                                                         .Encoded(false).Sanitized(false).SetWidth(10).RenderValueAs(m =>
                                                        @<b>
                                                        <button type="button" class="acao btn btn-primary glyphicon glyphicon-question-sign" data-toggle="modal" data-grupo="@m.grupo" data-subgrupo="@m.subgrupo" data-id="@m.OrientacaoAvaliacao" data-target="#myModal"></button>
                                                        </b>);
                                                    columns.Add().Encoded(false).Sanitized(false).SetWidth(2).RenderValueAs(m => @<b>
                        @Html.DropDownList(m.Id.ToString(), new SelectList(m.PunctuationList.OrderBy(i => i.Punctuation), "Punctuation", "Punctuation"), new { style = "width: 85px;", @class = "form-control ", required = "required" })
                    </b>);
                                                }
                                            }).Sortable(true).Filterable(true).WithMultipleFilters()
            </div>
