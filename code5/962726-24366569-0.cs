        if (_termAtt.Term.Contains("/"))
        {
            var tempArray = _termAtt.Term.Split('/');
            foreach (var item in tempArray)
            {
                _terms.Enqueue(item.ToCharArray());
            }
        }
        else
        {
            _terms.Enqueue(_termAtt.Term.ToCharArray());
        }
        return true;
