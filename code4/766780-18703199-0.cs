    @switch (Model.FeedType) // switch to cast correct Model Type in order to access proper DisplayAttribute for Interval1
    {
        case Model.FeedType.RSS:
            break;
        case Model.FeedType.XML:
        @Html.LabelFor(m => ((XmlDataSource)m).Interval1)
            break;
        case Model.FeedType.SqlServer:
            break;
        case Model.FeedType.Excel2003:
        @Html.LabelFor(m => ((Excel2003DataSource)m).Interval1)
            break;
        case Model.FeedType.InterLinkFeeder:
            break;
        case Model.FeedType.Atom:
            break;
        case Model.FeedType.Excel2007:
        @Html.LabelFor(m => ((Excel2007DataSource)m).Interval1)
            break;
        case Model.FeedType.JSON:
        @Html.LabelFor(m => ((JsonDataSource)m).Interval1)
            break;
        default:
            break;
    }
