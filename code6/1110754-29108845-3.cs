        [HttpGet]
        public ActionResult ViewAsset(int id = 0)
        {
            // Add Asset History to the View
            ViewBag.History = _repository.GetHistoryByAssetId(id)
            // Asset Details
            var asset = _assetRepository.GetAssetById(id);
            return View("AssetDetails", asset);
        }
