    var query = _videoRepository.Table.Join(
        _videoCategoryRepository.Table
    ,   v => v.CategoryId // <<== Use the proper ID here
    ,   vc => vc.Id
    ,   (v, vc) => new { Videos = v, VideoCategories = vc } // <<== This part is fine
    );
    foreach (var v in query) {
        Console.WriteLine("Video: '{0}'
        ,   category '{1}'"
        ,   v.Videos.Name
        ,   v.VideoCategories.Name
        );
    }
