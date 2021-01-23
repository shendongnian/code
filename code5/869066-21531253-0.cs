    @foreach (var i = 0; i < Option.GetDefaultOptions().Count; i++)
    {
        <li>
            @Html.TextBoxFor(model => Option.GetDefaultOptions()[i].OrderNo, new { id = Option.GetDefaultOptions()[i].IdString })
            @Html.ValidationMessageFor(model => Option.GetDefaultOptions()[i].OrderNo,
                                           null, new { data_valmsg_for = Option.GetDefaultOptions()[i].OrderNo.IdString })
        </li>
    }
