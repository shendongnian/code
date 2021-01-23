    this.olvColumn9.ImageGetter = delegate(object rowObject) {
        if (rowObject is Testaction) {
            Testaction action = rowObject as Testaction;
                if (action.Successful) {
                    return 0;
                } else {
                    return 1;
                }
        } else {
            return null;
        }
    };
    this.olvColumn9.AspectGetter = delegate(object rowObject) {
        if (rowObject is Milestone) {
            return ((Milestone)rowObject).Result.ToString();
        }
    };
