    List<RelatedProductViewModel> relatedProductViewModel
      = new List<RelatedProductViewModel>();
    foreach (var p in vm.RelatedProductID) {
      relatedProductViewModel.Add(
        new RelatedProductViewModel {
          RelatedProductID = p,
          ProductID = vm.ProductID,
          Type = vm.Type
        }
      );
    }
