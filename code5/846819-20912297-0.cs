      var city = _unitOfWork.Repository<City>().Query()
                .Include(c => c.Districts.Select(d => d.Users))
                .Filter(c => c.CityName.Equals(cityName, StringComparison.InvariantCultureIgnoreCase))
                .Get().FirstOrDefault();
            if (city != null)
            {
                var districts = city.Districts.ToList();
                for (var i = districts.Count - 1; i >= 0; i--)
                {
                    var users = districts[i].Users.ToList();
                    for (var j = users.Count - 1; j >= 0; j--)
                    {
                        users[j].DistrictId = null;
                        users[j].ObjectState = ObjectState.Modified;
                        _unitOfWork.Repository<User>().Update(users[j]);
                    }
                    districts[i].Users.Clear();
                    _unitOfWork.Repository<District>().Delete(districts[i]);
                }
                _unitOfWork.Repository<City>().Delete(city);
